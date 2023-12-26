using Microsoft.AspNetCore.Mvc;
using MyBlog.Models;

namespace MyBlog.Controllers
{
    public class PostController : Controller
    {
        
		private readonly List<Post> _listPosts;

		public PostController() 
        {
            _listPosts = GeneratePost();
        }
		/*public IActionResult Index()
        {
            Post post = new Post
            {
                Id = 1,
                Title = "Judulnya",
                Content = "Ini isi artikel",
                CreatedDate = DateTime.Now,
            };

            return View(post);
        }*/

		public IActionResult Index(int page = 1)
        {
            ViewBag.NextPage = page + 1;
            int dataPerpage = 10;
            int skip = dataPerpage * page - dataPerpage;
            List<Post> data = GeneratePost();
            List<Post> filtreddata = data
                //.Where(post =>post.Id<=10)
                .Skip(skip)
                .Take(dataPerpage)
                .OrderBy(post =>post.Id)//urutan dari yang terkecil
                //.OrderByDescending(post => post.Id)//urutan dari yang terbesar
                .ToList();
            return View(filtreddata);
        }


		/*public IActionResult Detail(string title)
        {
            ViewBag.Title = title;
            return View();
        }*/
		public IActionResult Detail(int id)
		{
			Post data = _listPosts.Where(post => post.Id == id).FirstOrDefault();   
			return View(data);
		}

		private List<Post> GeneratePost()
        {
            List<Post> posts = new List<Post>();
            int id = 1;
            for(int i=0; i<100; i++)
            {
                posts.Add(
                    new Post 
                    { 
                        Id = id,
                        Title = "Judul "+id,
                        Content = "ini isi artikel",
                        CreatedDate = DateTime.Now,
                    }
                );
                id++;
            }
            return posts;
        }
    }
}
