using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IaSiViziteaza.BLL.Abstractions;
using IaSiViziteaza.BLL.DTO;
using IaSiViziteaza.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IaSiViziteaza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {

        private readonly ICommentBusiness _business;

        public CommentController(ICommentBusiness bussines)
        {
            _business = bussines;
        }

        [HttpGet("{id}", Name = "GetCommentByAttractionId")]
        public ActionResult Get(Guid id)
        {
            var x = _business.GetCommentsByAttractionId(id);
            return Ok(x);
        }

        // POST: api/Comment
        [HttpPost]
        public ActionResult Post([FromBody] CommentDTO commentDTO)
        {
            if (commentDTO.CommentContent.Length == 0)
            {
                return Ok(false);
            }
            return Ok(_business.AddComment(commentDTO));
        }

        // PUT: api/Comment/5
        [Route("update")]
        [HttpPut]
        public void Put([FromBody] UpdateRatingDTO updateRatingDTO)
        {
            _business.UpdateCommentById(updateRatingDTO.Id, updateRatingDTO.Status);
        }

        // DELETE: api/ApiWithActions/5
        [Route("delete")]
        [HttpDelete]
        public ActionResult<bool> Delete(Guid id)
        {
            return Ok(_business.DeleteCommentById(id));
        }
    }
}
