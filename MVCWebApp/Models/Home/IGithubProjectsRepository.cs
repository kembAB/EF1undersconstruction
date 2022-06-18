using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp.Models.Home
{
    public interface IgithubProjectsRepository
    {
        IEnumerable<GithubProjectProperties> GetAllProjects { get; }
    }
}
