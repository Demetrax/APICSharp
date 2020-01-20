using ApiEval.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEval.Interfaces
{
    public interface IPublicationStore
    {
        List<Publication> publications { get; }

        //Ajout d'une publication
        void AddPublication(Publication publication);

        //Supression d'une publication
        void DelPublication(long id);

        //Modification d'une publication
        void UpdatePublication(long idPub, Publication publication);

        //Ajout d'un commentaire
        void AddComment(long idPublication, Commentaire commentaire);

        //Supression d'un commentaire
        void DelComment(long idPublication, long idComment);

        //Modification d'un commentaire
        void UpdateComment(long idPub, long idComm, Commentaire commentaire);
    }
}
