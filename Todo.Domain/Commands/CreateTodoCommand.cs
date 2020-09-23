﻿using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class CreateTodoCommand : Notifiable, ICommand
    {
        public CreateTodoCommand() { }

        public CreateTodoCommand(string title, string user, DateTime date)
        {
            Title = title;
            Date = date;
            User = user;
        }

        public string Title { get; private set; }
        public DateTime Date { get; private set; }
        public string User { get; private set; }

        public void Validate()
        {
            AddNotifications(
            new Contract()
                .Requires()
                .HasMinLen(Title, 3, "Title", "Por favor, descreva melhor esta tarefa!")
                .HasMinLen(User, 6, "User", "Usuário inválido")
            );
        }
    }
}