using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp.Models.Home
{
    class githubprojects : IgithubProjectsRepository
    {
        public IEnumerable<GithubProjectProperties> GetAllProjects =>
            new List<GithubProjectProperties>
            {
                new GithubProjectProperties {Title = "Calculator", Info = "A simple console calculator", Path = "https://github.com/kembAB/BasicCalculator"},
               
                new GithubProjectProperties {Title = "sokoban", Info = "sokoban game simulation with javascript",  Path = "https://github.com/kembAB/socobanTrial"},

                new GithubProjectProperties{Title = "Calculatorxunit", Info = "calculator with xunit testing ",Path = "https://github.com/kembAB/xunittestCalculator"}
            };
    }
}
