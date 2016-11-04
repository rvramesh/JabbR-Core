using System;
using JabbR_Core.Data.Models;
using Microsoft.AspNetCore.SignalR;
using JabbR_Core.Services;

namespace JabbR_Core.Commands
{
    [Command("addowner", "AddOwner_CommandInfo", "user [room]", "room")]
    public class AddOwnerCommand : UserCommand
    {
        public override void Execute(CommandContext context, CallerContext callerContext, ChatUser callingUser, string[] args)
        {
            if (args.Length == 0)
            {
                throw new HubException(LanguageResources.AddOwner_UserRequired);
            }

            string targetUserName = args[0];

            ChatUser targetUser = context.Repository.VerifyUser(targetUserName);

            string roomName = args.Length > 1 ? args[1] : callerContext.RoomName;

            if (String.IsNullOrEmpty(roomName))
            {
                throw new HubException(LanguageResources.AddOwner_RoomRequired);
            }

            ChatRoom targetRoom = context.Repository.VerifyRoom(roomName);

            context.Service.AddOwner(callingUser, targetUser, targetRoom);

            context.NotificationService.AddOwner(targetUser, targetRoom);

            context.Repository.CommitChanges();
            ChatRoomOwners toAdd = new ChatRoomOwners();
            toAdd.ChatRoomKey = targetRoom.Key;
            toAdd.ChatUserId = targetUser.Id;
        
            targetUser.OwnedRooms.Add(toAdd);

        }
    }
}