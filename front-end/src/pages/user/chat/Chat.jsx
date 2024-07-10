import { Paper } from "@mantine/core";
import { IconSearch } from "@tabler/icons-react";
import { CurrentRooms } from "./CurrentRooms";
import { ChatBox } from "./ChatBox";

const Chat = () => {
  const handleSearch = () => {};
  return (
    <Paper className="bg-[#282C35!] scrollbar-hide z-10 h-[100vh] overflow-y-hidden shadow-xl">
      <div className="flex">
        <Paper
          shadow="md"
          className="flex flex-col min-w-[360px] h-[100vh]  bg-[#ffff] relative"
        >
          <div className="h-16 p-4">
            <div className="flex">
              <a className="items-center relative -top-4 h-[90px]">
                <h3 className="text-xl text-black font-bold tracking-wider">
                  Conversations
                </h3>
              </a>
            </div>
          </div>
          <div>
            <div className="-mt-6 relative pt-6 px-4">
              <form onSubmit={(e) => e.preventDefault()}>
                <input
                  onChange={handleSearch}
                  className="w-[99.5%] bg-[#f6f6f6] text-[#111b21] tracking-wider pl-9 py-[8px] rounded-[9px] outline-0"
                  type="text"
                  name="search"
                  placeholder="Search"
                />
              </form>
              <div className="absolute top-[36px] left-[27px]">
                <IconSearch style={{ color: "#c4c4c5" }} />
              </div>
            </div>
            <CurrentRooms />
          </div>
        </Paper>
        <ChatBox />
      </div>
    </Paper>
  );
};

export default Chat;
