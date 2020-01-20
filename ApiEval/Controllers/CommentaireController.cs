using ApiEval.Interfaces;
using ApiEval.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace ApiEval.Controllers
{
    [ApiController]
    [Route("api/v1/touichter")]
    public class CommentaireController : ControllerBase
    {
        private IPublicationStore publicationStore;

        public CommentaireController(IPublicationStore publicationStore)
        {
            this.publicationStore = publicationStore;
        }

        [HttpGet("{idPub}/comments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        public ActionResult<IEnumerable<Commentaire>> GetComments(long idPub)
        {
            var publication = publicationStore.publications.FirstOrDefault(b => b.Id == idPub);
            if (publication == null)
            {
                return NotFound();
            }
            var comments = publication.Comments;
            return comments;
        }

        [HttpGet("{idPub}/comments/{idCom}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        public ActionResult<Commentaire> GetComment(long idPub, long idCom)
        {
            var publication = publicationStore.publications.FirstOrDefault(b => b.Id == idPub);
            if (publication == null)
            {
                return NotFound();
            }

            var comment = publication.Comments.FirstOrDefault(b => b.Id == idCom);
            if (comment == null)
            {
                return NotFound();
            }
            return comment;
        }

        [HttpPost("{idPub}/comments")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Consumes(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        public ActionResult<Commentaire> PostComment(long idPub, Commentaire commentaire)
        {
            publicationStore.AddComment(idPub,commentaire);

            return commentaire;
        }

        [HttpPut("{idPub}/comments/{idCom}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Consumes(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        public ActionResult<Commentaire> PutComment(long idPub, long idCom, Commentaire commentaire)
        {
            var publicationTmp = publicationStore.publications.FirstOrDefault(b => b.Id == idPub);
            if (publicationTmp == null)
            {
                return NotFound();
            }

            var comment = publicationTmp.Comments.FirstOrDefault(b => b.Id == idCom);
            if (comment == null)
            {
                return NotFound();
            }

            publicationStore.UpdateComment(idPub, idCom, commentaire);

            return comment;
        }

        [HttpDelete("{idPub}/comments/{idCom}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Consumes(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        public ActionResult<Publication> DelComment(long idPub, long idCom)
        {
            var publicationTmp = publicationStore.publications.FirstOrDefault(b => b.Id == idPub);
            if (publicationTmp == null)
            {
                return NotFound();
            }

            var comment = publicationTmp.Comments.FirstOrDefault(b => b.Id == idCom);
            if (comment == null)
            {
                return NotFound();
            }

            publicationStore.DelComment(idPub,idCom);
            return publicationTmp;
        }
    }
}
