using Refit;
using RefitExample.Models;

namespace RefitExample.Abstractions
{
    [Headers("Content-Type: application/json")]
    public interface IPostsClient
    {
        [Get("/posts/{postId}")]
        Task<PostDto> GetPostById(int postId);
    }
}