import { useState } from "react";
import { Group, Code } from "@mantine/core";
import {
  IconLogout,
  IconMessageChatbot,
  IconReportMoney,
  IconUser,
} from "@tabler/icons-react";

import { useAuth } from "../auth/AuthProvider";
import { useNavigate } from "react-router-dom";

const data = [
  { link: "profile", label: "User Profile", icon: IconUser },
  { link: "chat", label: "Conversation", icon: IconMessageChatbot },
  { link: "plans", label: "My Plans", icon: IconReportMoney },
];

export const Navbar = () => {
  const [active, setActive] = useState("User Profile");
  const { logOut } = useAuth();
  const navigate = useNavigate();

  const links = data.map((item) => (
    <a
      className="cursor-pointer flex items-center no-underline text-md text-slate-800 p-4 rounded-sm font-medium data-[active]:bg-[#228BE6]"
      data-active={item.label === active || undefined}
      key={item.label}
      onClick={(event) => {
        event.preventDefault();
        setActive(item.label);
        navigate(item.link);
      }}
    >
      <item.icon className=" mr-2 w-6 h-6" stroke={1.5} />
      <span>{item.label}</span>
    </a>
  ));

  return (
    <nav className="flex flex-col h-full">
      <div>{links}</div>
      <div className="flex-grow" />
      <div className="pt-4 mt-4 border-t border-solid border-gray-300">
        <a
          href="/login"
          className="flex items-center no-underline text-md text-slate-800 p-4 rounded-sm font-medium"
          onClick={() => logOut()}
        >
          <IconLogout className="mr-2 w-6 h-6" stroke={1.5} />
          <span>Logout</span>
        </a>
      </div>
    </nav>
  );
};
