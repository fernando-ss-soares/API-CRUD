using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taskify.Data;
using Task = Taskify.Models.Task;

namespace Taskify.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        // Conectando o banco de dados com a classe
        private TaskContext _context;

        public TaskController(TaskContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Task> ListTasks([FromQuery] int skip = 0, [FromQuery] int take = 30)
        {
            return _context.Tasks.Skip(skip).Take(take);
        }

        [HttpGet("{id}")]
        public IActionResult ListTaskId(int id)
        {
            var taskUnique = _context.Tasks.FirstOrDefault(filme => filme.Id == id);
            if (taskUnique == null)
            {
                return NotFound();
            }

            return Ok(taskUnique);
        }

        [HttpPost]
        public IActionResult CreateTask([FromBody] Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ListTaskId), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public IActionResult EditTask(int id, [FromBody] Task task) 
        {
            var taskEdit = _context.Tasks.FirstOrDefault(task => task.Id == id);
            
            if (taskEdit == null)
            {
                return NotFound();
            }

            taskEdit.Titulo = task.Titulo;
            taskEdit.Descricao = task.Descricao;
            taskEdit.Prioridade = task.Prioridade;


            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id) 
        {
            var taskRemove = _context.Tasks.FirstOrDefault(task => task.Id == id);
            if (taskRemove == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(taskRemove);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
