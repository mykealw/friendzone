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
        private readonly ProfileRepository _pr;

        public FollowsService(FollowsRepository repo, ProfileRepository pr)
        {
            _repo = repo;
            _pr = pr;
        }

        internal Follow Create(Follow follow)
        {
           Follow newFollow = _repo.Create(follow);
           return newFollow;
        }

        internal void Delete(int id, string userId)
        {
            Follow follow = Get(id);
            if (follow.FollowerId != userId)
            {
                throw new Exception("You Cannot Unfollow things that aren't yours to unfollow??");
            }
            _repo.Delete(id);
        }

        private Follow Get(int id)
        {
           Follow found = _repo.Get(id);
           if (found == null)
           {
               throw new Exception("Follow not found");
           }
           return found;
        }
    }
}