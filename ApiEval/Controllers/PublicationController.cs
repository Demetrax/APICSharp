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
    public class PublicationController : ControllerBase
    {
        private IPublicationStore publicationStore;

        public PublicationController(IPublicationStore publicationStore)
        {
            this.publicationStore = publicationStore;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        public IEnumerable<Publication> GetPublications()
        {
            return publicationStore.publications;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        public ActionResult<Publication> GetOnePublication(long id)
        {
            var publication = publicationStore.publications.FirstOrDefault(b => b.Id == id);
            if (publication == null)
            {
                return NotFound();
            }
            return publication;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Consumes(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        public ActionResult<Publication> PostPublication(Publication publication)
        {
            publicationStore.AddPublication(publication);

            return publication;
        }

        [HttpPut("{idPub}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Consumes(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        public ActionResult<Publication> PutPublication(long idPub, Publication publication)
        {
            var publicationTmp = publicationStore.publications.FirstOrDefault(b => b.Id == idPub);

            if (publicationTmp == null)
            {
                return NotFound();
            }

            publicationStore.UpdatePublication(idPub, publication);
            return publication;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Consumes(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        public ActionResult<Publication> DelPublication(long id)
        {
            var publicationTmp = publicationStore.publications.FirstOrDefault(b => b.Id == id);

            if (publicationTmp == null)
            {
                return NotFound();
            }

            publicationStore.DelPublication(id);
            return publicationTmp;
        }

    }
}
