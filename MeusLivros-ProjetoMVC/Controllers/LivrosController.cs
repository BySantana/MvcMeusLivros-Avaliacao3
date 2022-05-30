using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MeusLivros_ProjetoMVC.Data;
using MeusLivros_ProjetoMVC.Models;

namespace MeusLivros_ProjetoMVC.Controllers
{
    public class LivrosController : Controller
    {
        private readonly MeusLivros_ProjetoMVCContext _context;

        public LivrosController(MeusLivros_ProjetoMVCContext context)
        {
            _context = context;
        }

        // GET: Livros
        //public async Task<IActionResult> Index()
        //{
        //    var meusLivros_ProjetoMVCContext = _context.Livro.Include(l => l.Autor).Include(l => l.Editora).Include(l => l.Status);
        //    return View(await meusLivros_ProjetoMVCContext.ToListAsync());
        //}

        public ActionResult Index(string searchString, string bookGenre, string autor, string status)
        {
            var GenreLst = new List<string>();

            var GenreQry = from d in _context.Status
                           orderby d.Mensagem
                           select d.Mensagem;


            GenreLst.AddRange((IEnumerable<string>)GenreQry.Distinct());
            ViewBag.status = new SelectList(GenreLst);


            var livros = from l in _context.Livro.Include(l => l.Autor).Include(l => l.Editora).Include(l => l.Status)
                         select l;

            if (!String.IsNullOrEmpty(searchString))
            {
                livros = livros.Where(s => s.NomeLivro.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(bookGenre))
            {
                livros = livros.Where(x => x.Genero.Contains(bookGenre));
            }

            if (!string.IsNullOrEmpty(autor))
            {
                livros = livros.Where(d => d.Autor.NomeAutor.Contains(autor));
            }

            if (!string.IsNullOrEmpty(status))
            {
                livros = livros.Where(d => d.Status.Mensagem.Contains(status));
            }



            return View(livros);
        }

        // GET: Livros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Livro
                .Include(l => l.Autor)
                .Include(l => l.Editora)
                .Include(l => l.Status)
                .FirstOrDefaultAsync(m => m.LivroId == id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // GET: Livros/Create
        public IActionResult Create()
        {
            ViewData["AutorId"] = new SelectList(_context.Autor, "AutorId", "NomeAutor");
            ViewData["EditoraId"] = new SelectList(_context.Editora, "EditoraId", "NomeEditora");
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "Mensagem");
            return View();
        }

        // POST: Livros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LivroId,NomeLivro,EditoraId,AutorId,AnoPublicacao,StatusId,Genero,Nota")] Livro livro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(livro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutorId"] = new SelectList(_context.Autor, "AutorId", "NomeAutor", livro.AutorId);
            ViewData["EditoraId"] = new SelectList(_context.Editora, "EditoraId", "NomeEditora", livro.EditoraId);
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "Mensagem", livro.StatusId);
            return View(livro);
        }

        // GET: Livros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Livro.FindAsync(id);
            if (livro == null)
            {
                return NotFound();
            }
            ViewData["AutorId"] = new SelectList(_context.Autor, "AutorId", "NomeAutor", livro.AutorId);
            ViewData["EditoraId"] = new SelectList(_context.Editora, "EditoraId", "NomeEditora", livro.EditoraId);
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "Mensagem", livro.StatusId);
            return View(livro);
        }

        // POST: Livros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LivroId,NomeLivro,EditoraId,AutorId,AnoPublicacao,StatusId,Genero,Nota")] Livro livro)
        {
            if (id != livro.LivroId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(livro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LivroExists(livro.LivroId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutorId"] = new SelectList(_context.Autor, "AutorId", "NomeAutor", livro.AutorId);
            ViewData["EditoraId"] = new SelectList(_context.Editora, "EditoraId", "NomeEditora", livro.EditoraId);
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "Mensagem", livro.StatusId);
            return View(livro);
        }

        // GET: Livros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Livro
                .Include(l => l.Autor)
                .Include(l => l.Editora)
                .Include(l => l.Status)
                .FirstOrDefaultAsync(m => m.LivroId == id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // POST: Livros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var livro = await _context.Livro.FindAsync(id);
            _context.Livro.Remove(livro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LivroExists(int id)
        {
            return _context.Livro.Any(e => e.LivroId == id);
        }
    }
}
