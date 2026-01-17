using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XemPhimBan2.Models;

namespace XemPhimBan2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CachieuController : ControllerBase
{
    private readonly RapchieuphimContext _context;

    public CachieuController(RapchieuphimContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var ds = await _context.Cachieus.ToListAsync();
        return Ok(ds);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var ca = await _context.Cachieus.FindAsync(id);

        if (ca == null)
            return NotFound("Không tìm thấy ca chiếu!");

        return Ok(ca);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Cachieu model)
    {
        _context.Cachieus.Add(model);
        await _context.SaveChangesAsync();

        return Ok(new
        {
            message = "Tạo ca chiếu thành công!",
            data = model
        });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Cachieu model)
    {
        var ca = await _context.Cachieus.FindAsync(id);

        if (ca == null)
            return NotFound("Không tìm thấy ca chiếu!");

        ca.TenCa = model.TenCa;
        ca.GioBatDau = model.GioBatDau;
        ca.GioKetThuc = model.GioKetThuc;

        await _context.SaveChangesAsync();

        return Ok("Cập nhật ca chiếu thành công!");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var ca = await _context.Cachieus.FindAsync(id);

        if (ca == null)
            return NotFound("Không tìm thấy ca chiếu!");

        _context.Cachieus.Remove(ca);
        await _context.SaveChangesAsync();

        return Ok("Xóa ca chiếu thành công!");
    }
}
