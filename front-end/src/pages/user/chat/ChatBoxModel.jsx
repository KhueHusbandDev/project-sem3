import { ActionIcon, Avatar, Box, Modal, Paper } from "@mantine/core";
import { useDisclosure } from "@mantine/hooks";
import { IconCircleX, IconX } from "@tabler/icons-react";
import { useDispatch, useSelector } from "react-redux";
import { removeUserFromChat } from "../../../redux/chatRoomsSlice";
import { SearchResult } from "../../component/SearchResult";
import { useState } from "react";
import { SearchBar } from "../../component/SearchBar";

export const ChatBoxModel = () => {
  const dispatch = useDispatch();
  const { activeRoom } = useSelector((state) => state.rooms);
  const [search, setSearch] = useState("");

  const [isModalOpen, { open: openModal, close: closeModal }] =
    useDisclosure(false);

  const deleteMember = (userId) => {
    dispatch(removeUserFromChat(userId));
  };

  const onSelectUser = (user) => {
    dispatch(addUserToChat(user));
  };
  return (
    <>
      <Avatar src={activeRoom.chatImage} size={40} onClick={openModal} />
      {activeRoom.isGroup ? (
        <Modal
          classNames={{ title: "font-bold" }}
          opened={isModalOpen}
          onClose={closeModal}
          title={activeRoom.roomName}
        >
          <Box className="flex flex-col gap-y-2">
            <h6 className="text-[14px] text-[#111b21] tracking-wide font-semibold">
              Members
            </h6>
            <SearchBar handleSearch={setSearch} />
            <SearchResult
              onSelect={onSelectUser}
              search={search}
              searchResults={activeRoom.users}
            />
            <div className="flex flex-col flex-wrap gap-y-2">
              {activeRoom.users.map((user) => {
                return (
                  <Paper
                    h={45}
                    shadow="md"
                    key={user.id}
                    className="flex flex-row items-center gap-x-2 p-2"
                  >
                    <Avatar src={user.profilePic} size={30} />
                    <div>{user.name}</div>
                    <div className="flex-grow" />
                    <ActionIcon
                      className="bg-transparent rounded-full hover:bg-slate-200"
                      onClick={() => deleteMember(user.id)}
                    >
                      <IconCircleX
                        color="red"
                        className="place-self-center"
                        size={15}
                      />
                    </ActionIcon>
                  </Paper>
                );
              })}
            </div>
          </Box>
        </Modal>
      ) : (
        <Modal
          opened={isModalOpen}
          onClose={closeModal}
          classNames={{ body: "grid place-items-center" }}
        >
          <Paper
            shadow="md"
            w={250}
            h={250}
            className="flex flex-col items-center gap-4"
          >
            <Avatar size={70} src={activeRoom.chatImage} alt="" />
            <h2 className="text-xl tracking-wider font-semibold text-black">
              {activeRoom.chatName}
            </h2>

            <h3 className="text-[14px] font-semibold text-[#268d61]">
              {!activeRoom?.isGroup && activeRoom?.users?.[0].username
                ? activeRoom?.users[0]?.username
                : "-"}
            </h3>
            <div className="flex flex-col items-start">
              <h5 className="text-[13px]">
                {!activeRoom?.isGroup && activeRoom?.users?.[0]?.bio
                  ? activeRoom?.users[0]?.bio
                  : "-"}
              </h5>
            </div>
          </Paper>
        </Modal>
      )}
    </>
  );
};
