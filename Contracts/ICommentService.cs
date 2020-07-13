using Models.CommentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICommentService
    {
        IEnumerable<CommentListItem> GetAllCommentsByMonsterId(int monsterId);
        IEnumerable<CommentListItem> GetAllCommentsByCharacterId(int characterId);
        IEnumerable<CommentListItem> GetAllCommentsBySpellId(int spellId);
        bool CreateMonsterComment(CommentCreate model, int monsterId);
        bool CreateCharacterComment(CommentCreate model, int characterId);
        bool CreateSpellComment(CommentCreate model, int spellId);
        CommentListItem GetCommentById(int id);
        bool Edit(CommentEdit model);
        bool Delete(int id);
    }
}
