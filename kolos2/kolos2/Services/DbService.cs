using System.Collections;
using Microsoft.EntityFrameworkCore;
using kolos2.Data;
using kolos2.DTOs;
using kolos2.Models;

namespace kolos2.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }

}
