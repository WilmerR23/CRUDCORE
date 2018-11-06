using PracticarNetCore.Models;
using PracticarNetCore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticarNetCore.UWork
{
    public interface IUnitOfWork
    {
        IRepository<Pais> PaisRepository { get; }
        IRepository<Persona> PersonaRepository { get; }
        Task Save();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly Contexto _context;
        private IRepository<Pais> _paisRepository;
        private IRepository<Persona> _personaRepository;

        public UnitOfWork(Contexto context)
        {
           _context = context;
        }

        public IRepository<Pais> PaisRepository
        {
            get
            {
                return _paisRepository ?? new Repository<Pais>(_context);
            }
        }

        public IRepository<Persona> PersonaRepository
        {
            get
            {
                return _personaRepository ?? new Repository<Persona>(_context);
            }
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
