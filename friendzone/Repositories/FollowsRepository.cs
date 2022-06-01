using System;
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

        internal void Delete(int id)
        {
            string sql = "DELETE FROM follows WHERE id = @id LIMIT 1;";
            _db.Execute(sql, new {id});
        }

        internal Follow Get(int id)
        {
            string sql = @" 
           SELECT 
           p.*
           f.*
           FROM follows f
           JOIN profiles p ON f.followerId = p.id
           WHERE f.id = @id;";
            return _db.QueryFirstOrDefault<Follow>(sql, new { id });
        }
    }
}