import { faker } from "@faker-js/faker";
import { Paper } from "@mantine/core";
import clsx from "clsx";

import { useDispatch, useSelector } from "react-redux";
import { setActiveChat } from "../../../redux/chatRoomsSlice";
import { useEffect } from "react";

const createChatDummy = () => {
  const isGroup = faker.datatype.boolean();
  return {
    id: faker.string.uuid(),
    latestMessage: faker.lorem.sentence(5),
    chatImage: faker.image.url(),
    roomName: isGroup ? faker.company.name() : faker.person.fullName(),
    isGroup: isGroup,
    users: faker.helpers.multiple(createUsersDummy, {
      count: isGroup ? faker.number.int({ min: 2, max: 5 }) : 1,
    }),
  };
};
const createUsersDummy = () => {
  return {
    id: faker.string.uuid(),
    username: faker.internet.userName(),
    profilePic: faker.image.url(),
    bio: faker.person.bio(),
    name: faker.person.fullName(),
  };
};
const chats = faker.helpers.multiple(createChatDummy, { count: 5 });
export const CurrentRooms = () => {
  const dispatch = useDispatch();
  const { rooms, activeRoom } = useSelector((state) => state.rooms);

  return (
    <div className="no-scrollbar p-2 flex flex-col space-y-2 overflow-y-scroll h-[87vh] pb-10 border">
      {chats.map((currentRoom) => {
        return (
          <Paper
            shadow="xs"
            onClick={() => {
              dispatch(setActiveChat(currentRoom));
            }}
            key={currentRoom.id}
            className={clsx(
              "flex items-start gap-4",
              activeRoom.id === currentRoom.id ? "bg-[#fafafa]" : "bg-[#fff]",
              "cursor-pointer py-4 px-2"
            )}
          >
            <img
              className="w-12 h-12 rounded-full shadow-lg object-cover"
              src={currentRoom.chatImage}
            />
            <div className="flex flex-col">
              <h5 className="self-start text-black font-bold">
                {currentRoom.roomName}
              </h5>
              <p className="self-start font-normal text-slate-400">
                {currentRoom.latestMessage}
              </p>
            </div>
          </Paper>
        );
      })}
    </div>
  );
};
