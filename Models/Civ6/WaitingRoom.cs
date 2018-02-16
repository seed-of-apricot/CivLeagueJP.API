using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CivLeagueJP.API.Models.Civ6.WaitingRoom
{
    public class UI
    {
        public int Id { get; set; }
        public UserViewModel CurrentUser { get; set; }
        public List<BoardViewModel> Boards { get; set; }
    }

    [Table("Civ6WaitingRoomBoards")]
    public class Board
    {
        public Board()
        {
            BoardUsers = new List<BoardUser>();
            Posts = new List<Post>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<BoardUser> BoardUsers { get; set; } = new List<BoardUser>();
        public virtual List<Post> Posts { get; set; }
        public MatchStatus MatchStatus { get; set; }
    }

    public class BoardViewModel
    {
        public BoardViewModel(Board board)
        {
            Id = board.Id;
            Name = board.Name;
            Posts = board.Posts;
            Users = board.BoardUsers.Select(t => t.User).ToList();
            MatchStatus = board.MatchStatus;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string MessageToPost { get; set; }
        public virtual List<User> Users { get; set; }
        public virtual List<Post> Posts { get; set; }
        public MatchStatus MatchStatus { get; set; }
    }

    [Table("Civ6WaitingRoomPosts")]
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime DatePosted { get; set; }
        public long PostUserId { get; set; }
        public string PostUserName { get; set; }
    }

    [Table("Civ6WaitingRoomUsers")]
    public class User
    {
        public User(UserViewModel user)
        {
            Id = user.Id;
            UserName = user.UserName;
        }
        public User()
        {
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }
        public string UserName { get; set; }
        public virtual List<BoardUser> BoardUsers { get; set; } = new List<BoardUser>();
    }

    public class BoardUser
    {
        public int Id { get; set; }
        public int BoardId { get; set; }
        public Board Board { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
    }

    public class UserViewModel
    {
        public UserViewModel(Player user)
        {
            Id = user.Id;
            UserName = user.DisplayName;
        }
        public UserViewModel()
        {
            Id = 0;
            UserName = "Guest";
        }
        public long Id { get; set; }
        public string UserName { get; set; }
    }
}
