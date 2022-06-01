using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using friendzone.Models;
using friendzone.Repositories;

namespace friendzone.Services
{
    public class FollowsService
    {
        private readonly FollowsRepository _repo;

        public FollowsService(FollowsRepository repo)
        {
            _repo = repo;
        }

        internal Follow Create(Follow follow)
        {
           Follow newFollow = _repo.Create(follow);
           return newFollow;
        }
    }
}