using logo_odev5.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace logo_odev5.Business.Abstracts
{
    public interface IPostService
    {
        Post GetPostById(Expression<Func<Post, bool>> filter);
        List<Post> GetAllPosts();
        Task AddPost(Post post, CancellationToken cancellationToken = default);
    }
}
