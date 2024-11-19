using AutoMapper;
using LibraryCrud.Api.DTOS.BookDTOS;
using LibraryCrud.Domain.Entities;
using LibraryCrud.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryCrud.Api.Controllers
{
    public class BookController : BaseApiController
    {
        public BookController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        [HttpGet("GetBookByAuthor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<BookDto>> GetBookByAuthor(string authorName)
        {
            try
            {
                if (authorName != null)
                {
                    List<Book> books = await _unitOfWork.Books.GetBookByAuthor(authorName);
                    if (books != null)
                    {
                        return Ok(_mapper.Map<List<BookDto>>(books));
                    }
                    return NotFound();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, (ex.Message));
            }
        }



        [HttpGet("GetBookByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]


        public async Task<ActionResult<List<BookDto>>> GetBookByName(string bookName)
        {
            try
            {
                if (bookName != null)
                {
                    List<Book> books = await _unitOfWork.Books.GetByName(bookName);
                    if (books != null)
                    {
                        return Ok(_mapper.Map<List<BookDto>>(books));

                    }
                    return NotFound();

                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }


        }

        [HttpGet("GetAllBooks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<List<BookNameDto>>> GetAllBooks()
        {
            try
            {
                var books = await _unitOfWork.Books.GetAll();
                if (books != null)
                {
                    return Ok(_mapper.Map<List<BookNameDto>>(books));
                }
                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }

        }

        [HttpGet("GetAllBooksAndLists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<List<BookDto>>> GetAllBooksAndLists()
        {
            try
            {
                var books = await _unitOfWork.Books.GetAllBooksLists();
                if (books != null)
                {
                    return Ok(_mapper.Map<List<BookDto>>(books));
                }
                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }

        }
        [HttpPost("AddBook")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]



        public async Task<ActionResult> AddBook(AddBookDto model)
        {
            try
            {
                if (model != null)
                {   
                    Book book = _mapper.Map<Book>(model);
                    book.PublicationDate = DateTime.Now;
                    bool isChange = await _unitOfWork.Books.verifyAndAddInexistingAuthor(book);

                    if (isChange)
                    {
                        var bookDto = _mapper.Map<AddBookDto>(book);
                        return CreatedAtAction(nameof(AddBook), new { id = bookDto.BookId }, bookDto);

                    }

                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPut("UpdateBook")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> UpdateBook([FromBody] AddBookDto book)
        {
            try
            {
                if (book != null)
                {
                    var existingBook = await _unitOfWork.Books.GetById(book.BookId);
                    if (existingBook != null)
                    {
                        Book bookToUpdate = _mapper.Map<Book>(book);
                        bool isUpdate = await _unitOfWork.Books.UpdateBook(bookToUpdate);
                        if (isUpdate)
                        {
                            return NoContent();
                        }

                    }
                    return NotFound();

                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }

        }

        [HttpDelete("DeleteBook")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> DeleteBook(int bookId) 
        {
            try 
            {       
                if(bookId > 0) 
                {
                    Book bookToRemove = await _unitOfWork.Books.GetById(bookId);
                    if(bookToRemove != null) 
                    {
                        _unitOfWork.Books.Remove(bookToRemove);
                        await _unitOfWork.SaveAsync();
                        return NoContent();
                    
                    }
                    return NotFound();
                
                }
                return BadRequest();
            }catch(Exception ex)             
            {
                return StatusCode(500, ex.Message);

            }
        
        }




    }
}
