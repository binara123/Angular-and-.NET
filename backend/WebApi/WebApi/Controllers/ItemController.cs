using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class ItemsController : ControllerBase
{
    private static List<Item> Items = new List<Item>
    {
        new Item { Id = 1, Name = "Item 1" },
        new Item { Id = 2, Name = "Item 2" }
    };

    [HttpGet]
    public IActionResult GetItems() => Ok(Items);

    [HttpPost]
    public IActionResult AddItem([FromBody] Item newItem)
    {
        
        //newItem.Id = Items.Count > 0 ? Items.Max(i => i.Id) + 1 : 1;
        Items.Add(newItem);
        return CreatedAtAction(nameof(GetItems), new { id = newItem.Id }, newItem);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateItem(int id, [FromBody] Item updatedItem)
    {
        var item = Items.FirstOrDefault(i => i.Id == id);
        if (item == null)
            return NotFound();

        item.Name = updatedItem.Name;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteItem(int id)
    {
        var item = Items.FirstOrDefault(i => i.Id == id);
        if (item == null)
            return NotFound();

        Items.Remove(item);
        return NoContent();
    }
}

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
}