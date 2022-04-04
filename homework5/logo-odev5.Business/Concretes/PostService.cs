using logo_odev5.DataAccess.EntityFramework.Repository.Abstracts;
using logo_odev5.Domain.Entities;
using logo_odev5.Business.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Threading;

namespace logo_odev5.Business.Concretes
{
    public class PostService : IPostService
    {
        private readonly IRepository<Post> repository;
        private readonly IUnitOfWork unitOfWork;
        public PostService(IRepository<Post> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public List<Post> GetAllPosts()
        {
            return repository.Get().ToList();
        }
        public Post GetPostById(Expression<Func<Post, bool>> filter)
        {
            return repository.GetById(filter);
        }
        public async Task AddPost(Post post, CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                repository.Add(post);
                unitOfWork.Commit();
            }, cancellationToken);
        }
    }
}
