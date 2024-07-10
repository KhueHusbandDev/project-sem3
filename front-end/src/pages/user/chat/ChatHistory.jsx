import { Avatar, Tooltip } from "@mantine/core";
import ScrollableFeed from "react-scrollable-feed";
import {
  isLastMessage,
  isSameSender,
  isSameSenderMargin,
  isSameUser,
} from "../../../helpers/chatHelpers";
import { faker } from "@faker-js/faker";
export const ChatHistory = () => {
  const activeUser = faker.string.uuid();
  const createMessageDummy = () => {
    return {
      sender: {
        _id: faker.datatype.boolean() ? faker.string.uuid() : activeUser,
        name: faker.person.fullName(),
        profilePic: faker.image.avatar(),
      },
      content: faker.lorem.sentence(),
      createdAt: new Date(),
    };
  };
  const messages = faker.helpers.multiple(createMessageDummy, { count: 100 });

  return (
    <>
      <ScrollableFeed>
        {messages &&
          messages.map((m, i) => (
            <div className="flex items-center gap-x-[6px]" key={m._id}>
              {(isSameSender(messages, m, i, activeUser) ||
                isLastMessage(messages, i, activeUser)) && (
                <Tooltip
                  label={m.sender?.name}
                  placement="bottom-start"
                  hasArrow
                >
                  <Avatar
                    w={32}
                    h={32}
                    name={m.sender?.name}
                    src={m.sender?.profilePic}
                    borderRadius="25px"
                  />
                </Tooltip>
              )}
              <span
                className="tracking-wider text-[15px] font-medium"
                style={{
                  backgroundColor: `${
                    m.sender._id === activeUser ? "#FFC0CB" : "#f0f0f0"
                  }`,
                  marginLeft: isSameSenderMargin(messages, m, i, activeUser),
                  marginTop: isSameUser(messages, m, i, activeUser) ? 3 : 10,
                  borderRadius: `${
                    m.sender._id === activeUser
                      ? "10px 10px 0px 10px"
                      : "10px 10px 10px 0"
                  }`,
                  padding: "10px 18px",
                  maxWidth: "460px",
                  color: `${m.sender._id === activeUser ? "#ffff" : "#848587"}`,
                }}
              >
                {m.content}
              </span>
            </div>
          ))}
      </ScrollableFeed>
    </>
  );
};
