﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SapiensDataAPI.Data.DbContextCs;
using SapiensDataAPI.Dtos.Income.Request;
using SapiensDataAPI.Models;

namespace SapiensDataAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class IncomesController(SapeinsDataDbContext context, IMapper mapper) : ControllerBase
	{
		private readonly SapeinsDataDbContext _context = context;
		private readonly IMapper _mapper = mapper;

		// GET: api/Incomes
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Income>>> GetIncomes()
		{
			return await _context.Incomes.ToListAsync();
		}

		// GET: api/Incomes/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Income>> GetIncome(int id)
		{
			Income? income = await _context.Incomes.FindAsync(id);

			if (income == null)
			{
				return NotFound();
			}

			return income;
		}

		// PUT: api/Incomes/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutIncome(int id, Income income)
		{
			if (id != income.IncomeId)
			{
				return BadRequest();
			}

			_context.Entry(income).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!IncomeExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/Incomes
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Income>> PostIncome(IncomeDto incomeDto)
		{
			Income income = _mapper.Map<Income>(incomeDto);
			_context.Incomes.Add(income);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetIncome", new { id = income.IncomeId }, income);
		}

		// DELETE: api/Incomes/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteIncome(int id)
		{
			Income? income = await _context.Incomes.FindAsync(id);
			if (income == null)
			{
				return NotFound();
			}

			_context.Incomes.Remove(income);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool IncomeExists(int id)
		{
			return _context.Incomes.Any(e => e.IncomeId == id);
		}
	}
}