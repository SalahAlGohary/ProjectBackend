﻿using Project.Backend.Entities;

namespace Project.Backend.Repositories
{
    public abstract class RecommendationRepository : GenericRepository<Recommendation>
    {
        ProjectDBContext _context;
        public RecommendationRepository(ProjectDBContext context) : base(context)
        {
            _context = context;
        }

    }
}