using ApiEval.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEval.Models
{
    public class PublicationStore : IPublicationStore
    {
        public List<Publication> publications { get; } = new List<Publication>();

        public PublicationStore()
        {
            //Creation exemple
            Publication publicationEx = new Publication();
            Commentaire commentaireEx = new Commentaire();
            Commentaire commentaireEx2 = new Commentaire();
            publicationEx.Author = "Jaques Lopez";
            publicationEx.Content = "blabla bla lba bla";
            publicationEx.Title = "Test";
            publicationEx.Id = 1;
            commentaireEx.Author = "PouetDude";
            commentaireEx.Content = "LOL ^^ \\[T]//";
            commentaireEx.Id = 1;
            publicationEx.Comments.Add(commentaireEx);
            commentaireEx2.Author = "Fabio LANZONI";
            commentaireEx2.Content = "Faaaaaaaaaaabuleux !";
            commentaireEx2.Id = 2;
            publicationEx.Comments.Add(commentaireEx2);
            publications.Add(publicationEx);
        }

        

        public void AddComment(long idPublication, Commentaire commentaire)
        {
            var publication = publications.FirstOrDefault(b => b.Id == idPublication);
            commentaire.Id = publication.Comments.Any() ? (publication.Comments.Max(b => b.Id) + 1) : 1;
            publication.Comments.Add(commentaire);
        }

        public void AddPublication(Publication publication)
        {
            publication.Id = publications.Any() ? (publications.Max(b => b.Id) + 1) : 1;
            publications.Add(publication);
        }

        public void DelComment(long idPublication, long idComment)
        {
            var publication = publications.FirstOrDefault(b => b.Id == idPublication);
            var comment = publication.Comments.FirstOrDefault(b => b.Id == idComment);
            publication.Comments.Remove(comment);
        }

        public void DelPublication(long id)
        {
            var publication = publications.FirstOrDefault(b => b.Id == id);
            publications.Remove(publication);
        }

        public void UpdatePublication(long idPub, Publication publication)
        {
            var publicationTmp = publications.FirstOrDefault(b => b.Id == idPub);
            var index = publications.IndexOf(publicationTmp);
            publicationTmp.Author = publication.Author;
            publicationTmp.Content = publication.Content;
            publicationTmp.Title = publication.Title;

            publications[index] = publicationTmp;
        }

        public void UpdateComment(long idPub, long idCom, Commentaire commentaire)
        {
            var publicationTmp = publications.FirstOrDefault(b => b.Id == idPub);
            var indexPub = publications.IndexOf(publicationTmp);
            var commentTmp = publicationTmp.Comments.FirstOrDefault(b => b.Id == idCom);
            var indexCom = publicationTmp.Comments.IndexOf(commentTmp);
            commentTmp.Content = commentaire.Content;
            commentTmp.Author = commentaire.Author;

            publicationTmp.Comments[indexCom] = commentTmp;
            publications[indexPub] = publicationTmp;
        }
    }
}
