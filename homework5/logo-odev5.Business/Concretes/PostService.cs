using logo_odev5.DataAccess.EntityFramework.Repository.Abstracts;
using logo_odev5.Domain.Entities;
using logo_odev5.Business.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace logo_odev5.Business.Concretes
{
    public class PostService : IPostService
    {
        private readonly IRepository<Post> repository;
        public PostService(IRepository<Post> repository)
        {
            this.repository = repository;
        }

        public List<Post> GetAllPosts()
        {
            return repository.Get().ToList();
        }
        public Post GetPostById(Expression<Func<Post, bool>> filter)
        {
            return repository.GetById(filter);
        }
    }
}
