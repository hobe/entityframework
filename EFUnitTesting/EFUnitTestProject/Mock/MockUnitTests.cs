﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Cubido.Data;
using System.Data.Entity;
using Cubido.Data.Entities;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;

namespace EFUnitTestProject
{
    [TestClass]
    public class MockUnitTests
    {
        [TestClass]
        public class NonQueryTests
        {
            [TestMethod]
            public void CreateBlog_saves_a_blog_via_context()
            {
                var mockSet = new Mock<DbSet<Blog>>();

                var mockContext = new Mock<BloggingContext>();
                mockContext.Setup(m => m.Blogs).Returns(mockSet.Object);

                var service = new BlogService(mockContext.Object);

                // Business Logic Code:
                service.AddBlog("ADO.NET Blog", "http://blogs.msdn.com/adonet");

                mockSet.Verify(m => m.Add(It.IsAny<Blog>()), Times.Once());
                mockContext.Verify(m => m.SaveChanges(), Times.Once());
            }

            [TestMethod]
            public void GetAllBlogs_orders_by_name()
            {
                var data = new List<Blog>
                {
                    new Blog { Name = "BBB" },
                    new Blog { Name = "ZZZ" },
                    new Blog { Name = "AAA" },
                }.AsQueryable();

                var mockSet = new Mock<DbSet<Blog>>();
                mockSet.As<IQueryable<Blog>>().Setup(m => m.Provider).Returns(data.Provider);
                mockSet.As<IQueryable<Blog>>().Setup(m => m.Expression).Returns(data.Expression);
                mockSet.As<IQueryable<Blog>>().Setup(m => m.ElementType).Returns(data.ElementType);
                mockSet.As<IQueryable<Blog>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

                var mockContext = new Mock<BloggingContext>();
                mockContext.Setup(c => c.Blogs).Returns(mockSet.Object);

                var service = new BlogService(mockContext.Object);


                /// BL to test
                var blogs = service.GetAllBlogs();

                Assert.AreEqual(3, blogs.Count);
                Assert.AreEqual("AAA", blogs[0].Name);
                Assert.AreEqual("BBB", blogs[1].Name);
                Assert.AreEqual("ZZZ", blogs[2].Name);
            }

            [TestMethod]
            public async Task GetAllBlogsAsync_orders_by_name()
            {

                var data = new List<Blog>
                {
                    new Blog { Name = "BBB" },
                    new Blog { Name = "ZZZ" },
                    new Blog { Name = "AAA" },
                }.AsQueryable();

                var mockSet = new Mock<DbSet<Blog>>();
                mockSet.As<IDbAsyncEnumerable<Blog>>()
                    .Setup(m => m.GetAsyncEnumerator())
                    .Returns(new TestDbAsyncEnumerator<Blog>(data.GetEnumerator()));

                mockSet.As<IQueryable<Blog>>()
                    .Setup(m => m.Provider)
                    .Returns(new TestDbAsyncQueryProvider<Blog>(data.Provider));

                mockSet.As<IQueryable<Blog>>().Setup(m => m.Expression).Returns(data.Expression);
                mockSet.As<IQueryable<Blog>>().Setup(m => m.ElementType).Returns(data.ElementType);
                mockSet.As<IQueryable<Blog>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

                var mockContext = new Mock<BloggingContext>();
                mockContext.Setup(c => c.Blogs).Returns(mockSet.Object);

                var service = new BlogService(mockContext.Object);
                var blogs = await service.GetAllBlogsAsync();

                Assert.AreEqual(3, blogs.Count);
                Assert.AreEqual("AAA", blogs[0].Name);
                Assert.AreEqual("BBB", blogs[1].Name);
                Assert.AreEqual("ZZZ", blogs[2].Name);
            }
        }
    }
}
