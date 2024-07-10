import { useSelector } from "react-redux";
import { ChatBoxModel } from "./ChatBoxModel";
import { ChatHistory } from "./ChatHistory";
import { ChatInput } from "./ChatInput";
import { useState } from "react";

export const ChatBox = () => {
  const { activeRoom } = useSelector((state) => state.rooms);
  const [messages, setMessages] = useState("");
  return (
    <div className="relative lg:w-[100%] h-[100vh] bg-[#fafafa] bg-scroll-[#fafafa]">
      <div className="flex justify-between items-center px-5 bg-[#ffff] w-[100%]">
        <div className="flex items-center gap-x-[10px]">
          <div className="flex flex-col items-start justify-center">
            <h5 className="text-[17px] text-[#2b2e33] font-bold tracking-wide">
              {activeRoom.roomName}
            </h5>
          </div>
        </div>
        <div>
          <ChatBoxModel />
        </div>
      </div>
      <div className=" no-scrollbar w-[100%] h-[70vh] md:h-[66vh] lg:h-[69vh] flex flex-col p-4">
        <ChatHistory />
      </div>
      <ChatInput />
    </div>
  );
};
