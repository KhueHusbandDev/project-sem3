import { Avatar, Group, Menu, Text, UnstyledButton, rem } from "@mantine/core";
import {
  IconChevronDown,
  IconLogout,
  IconUserCircle,
} from "@tabler/icons-react";
import { useAuth } from "../auth/AuthProvider";
import { faker } from "@faker-js/faker";
import { Navigate, useNavigate } from "react-router-dom";

export const UserMenu = () => {
  const { user, logOut } = useAuth();
  const navigate = useNavigate();
  return (
    <Menu
      width={260}
      position="bottom-end"
      withinPortal
      className="bg-slate-100 p-4 rounded-full flex items-center"
    >
      <Menu.Target>
        <UnstyledButton>
          <Group gap={8}>
            <div className="border-solid border-slate-300 border-[1px] p-2 rounded-full">
              <Avatar src={faker.image.url()} radius="xl" size={20} />
            </div>
            <Text fw={500} size="sm" lh={1} mr={3}>
              {user.username}
            </Text>
            <IconChevronDown
              style={{ width: rem(12), height: rem(12) }}
              stroke={1.5}
            />
          </Group>
        </UnstyledButton>
      </Menu.Target>
      <Menu.Dropdown>
        <Menu.Item
          leftSection={
            <IconUserCircle
              style={{ width: rem(16), height: rem(16) }}
              stroke={1.5}
            />
          }
          onClick={() => {
            navigate("profile");
          }}
        >
          Your Profile
        </Menu.Item>
        <Menu.Item
          leftSection={
            <IconLogout
              style={{ width: rem(16), height: rem(16) }}
              stroke={1.5}
            />
          }
          onClick={() => {
            logOut();
          }}
        >
          Logout
        </Menu.Item>
      </Menu.Dropdown>
    </Menu>
  );
};
