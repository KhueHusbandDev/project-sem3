import { ActionIcon } from "@mantine/core";
import { useDisclosure } from "@mantine/hooks";
import { IconIcons, IconIconsOff } from "@tabler/icons-react";
import EmojiPicker from "emoji-picker-react";
import React, { useState } from "react";

export const ChatInput = () => {
  const [isOpenIcon, { toggle: toggleIcon }] = useDisclosure(false);
  const [message, setMessage] = useState("");
  console.log("message: ", message);
  return (
    <>
      <div className="absolute bottom-12 right-12 w-[600px]">
        {isOpenIcon && (
          <EmojiPicker
            open={isOpenIcon}
            onEmojiClick={(value) => {
              setMessage((message) => message + value.emoji);
            }}
          />
        )}
        <div className="border-[1px] border-[#aabac8] px-6 py-3 w-full h-[50px] rounded-t-[10px]">
          <form
          // onKeyDown={(e) => setMessage(e)}
          // onSubmit={(e) => e.preventDefault()}
          >
            <input
              // onChange={(e) => {
              //   setMessage(e.target.value);
              //   if (!socketConnected) return;
              //   if (!typing) {
              //     setTyping(true);
              //     socket.emit("typing", activeChat._id);
              //   }
              //   let lastTime = new Date().getTime();
              //   var time = 3000;
              //   setTimeout(() => {
              //     var timeNow = new Date().getTime();
              //     var timeDiff = timeNow - lastTime;
              //     if (timeDiff >= time && typing) {
              //       socket.emit("stop typing", activeChat._id);
              //       setTyping(false);
              //     }
              //   }, time);
              // }}
              className="focus:outline-0 w-[100%] bg-[#f8f9fa]"
              type="text"
              name="message"
              placeholder="Enter message"
              value={message}
              onChange={(e) => setMessage(e.target.value)}
            />
          </form>
        </div>
        <div className="border-x-[1px] border-b-[1px] bg-[#f8f9fa] border-[#aabac8] px-6 py-3 w-full rounded-b-[10px] h-[50px]">
          {/* {
      isTyping ? <div>Loading</div> : ""
    } */}

          <div className="flex justify-between items-start">
            {isOpenIcon ? (
              <ActionIcon onClick={toggleIcon}>
                <IconIconsOff size={20} />
              </ActionIcon>
            ) : (
              <ActionIcon onClick={toggleIcon}>
                <IconIcons size={20} />
              </ActionIcon>
            )}

            <button
              //   onClick={(e) => keyDownFunction(e)}
              className="bg-[#f8f9fa] border-[2px] border-[#d4d4d4] text-[14px] px-2 py-[3px] text-[#9e9e9e] font-medium rounded-[7px] -mt-1"
            >
              Send
            </button>
          </div>
        </div>
      </div>
    </>
  );
};
