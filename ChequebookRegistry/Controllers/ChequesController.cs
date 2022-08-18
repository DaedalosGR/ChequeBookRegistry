using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChequebookRegistry.Data;
using ChequebookRegistry.Models;
using System.Dynamic;
using ChequebookRegistry.Models.ViewModels;
using Microsoft.Data.SqlClient;

namespace ChequebookRegistry.Controllers
{
    public class ChequesController : Controller
    {
        private readonly ChequebookRegistryContext _context;

        public ChequesController(ChequebookRegistryContext context)
        {
            _context = context;
        }

        // GET: Cheques
        public async Task<IActionResult> Index()
        {
              return _context.Cheques != null ? 
                          View(await _context.Cheques.ToListAsync()) :
                          Problem("Entity set 'ChequebookRegistryContext.Cheques'  is null.");
        }

        // GET: Cheques/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cheques == null)
            {
                return NotFound();
            }

            var cheques = await _context.Cheques
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cheques == null)
            {
                return NotFound();
            }

            return View(cheques);
        }

        // GET: Cheques/Create
        public IActionResult Create()
        {
            CreateViewModel model = new CreateViewModel();
            //CustomerList model = new CustomerList();
            //dynamic viewModel = new ExpandoObject();
            model.CustomersList = CustomersList();
            model.PayeesList = PayeesList();
            return View(model);
            //return View();
        }

        // POST: Cheques/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Payee,Amount,DateDue,Justification,RelatedCustomer")] Cheques cheques)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cheques);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cheques);
        }

        // GET: Cheques/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cheques == null)
            {
                return NotFound();
            }

            var cheques = await _context.Cheques.FindAsync(id);
            if (cheques == null)
            {
                return NotFound();
            }
            return View(cheques);
        }

        // POST: Cheques/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Payee,Amount,DateDue,Justification,RelatedCustomer")] Cheques cheques)
        {
            if (id != cheques.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cheques);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChequesExists(cheques.Id))
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
            return View(cheques);
        }

        // GET: Cheques/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cheques == null)
            {
                return NotFound();
            }

            var cheques = await _context.Cheques
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cheques == null)
            {
                return NotFound();
            }

            return View(cheques);
        }

        // POST: Cheques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cheques == null)
            {
                return Problem("Entity set 'ChequebookRegistryContext.Cheques'  is null.");
            }
            var cheques = await _context.Cheques.FindAsync(id);
            if (cheques != null)
            {
                _context.Cheques.Remove(cheques);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChequesExists(int id)
        {
          return (_context.Cheques?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        //
        // GET: /Home/
        private static List<SelectListItem> CustomersList()
        {
            List<SelectListItem> customer = new List<SelectListItem>();
            string constr = "data source=daedalospc01;initial catalog=Chequebook;user id=sa;password=asdQWE123!";
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "select Id, Name from[Chequebook].[dbo].[Customers]";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            customer.Add(new SelectListItem
                            {
                                Value = dr["Id"].ToString(),
                                Text = dr["Name"].ToString()

                            });
                        }
                    }
                    con.Close();
                }
            }
            return customer;
        }

        //
        // GET: /Home/
        private static List<SelectListItem> PayeesList()
        {
            List<SelectListItem> customer = new List<SelectListItem>();
            string constr = "data source=daedalospc01;initial catalog=Chequebook;user id=sa;password=asdQWE123!";
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "select Id, PayeeName from[Chequebook].[dbo].[Payees]";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            customer.Add(new SelectListItem
                            {
                                Value = dr["Id"].ToString(),
                                Text = dr["PayeeName"].ToString()

                            });
                        }
                    }
                    con.Close();
                }
            }
            return customer;
        }

    }
}
