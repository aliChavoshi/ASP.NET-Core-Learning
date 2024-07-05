using aspLearning.Entities;
using aspLearning.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace aspLearning.Services;

public class AuthorRepository(DbContext myContext) : GenericRepository<Author>(myContext), IAuthorRepository
{
}