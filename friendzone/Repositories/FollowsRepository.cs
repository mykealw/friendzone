using System.Data;
using Dapper;
using friendzone.Models;

namespace friendzone.Repositories
{
    public class FollowsRepository
    {
        private readonly IDbConnection _db;

        internal Follow Create(Follow follow)
        {
            string sql = @" 
            INSERT INTO follows
            (followerId, FollowingId)
            VALUES
            (@FollowerId, @FollowingId);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, follow);
            follow.Id = id;
            return follow;
        }
    }
}