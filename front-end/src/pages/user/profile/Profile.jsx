import { faker } from "@faker-js/faker";
import { Button, Image, Paper, Tabs } from "@mantine/core";
import { useAuth } from "../../auth/AuthProvider";
import {
  IconEdit,
  IconInfoCircle,
  IconUserPlus,
  IconUsersGroup,
} from "@tabler/icons-react";
import { Infomation } from "./Infomation";
import { Contacts } from "./Contacts";
import { useDisclosure } from "@mantine/hooks";
import { useState } from "react";
import { ContactModals } from "./ContactsModal";

const Profile = () => {
  const [isEdit, { open: openEdit, close: closeEdit }] = useDisclosure(false);
  const [isOpenModal, { open: openModal, close: closeModal }] =
    useDisclosure(false);

  const [currentTab, setCurrentTab] = useState("infomation");

  const tabButton = {
    infomation: (
      <Button
        key={"information"}
        className="absolute right-4 bottom-4"
        leftSection={<IconEdit />}
        onClick={openEdit}
      >
        Edit Profile
      </Button>
    ),
    contacts: (
      <Button
        key={"contacts"}
        className="absolute right-4 bottom-4"
        leftSection={<IconUserPlus />}
        onClick={openModal}
      >
        Add New Contact
      </Button>
    ),
  };

  return (
    <>
      <ContactModals isOpen={isOpenModal} onClose={closeModal} />
      <div className="w-full h-full flex flex-col gap-8">
        <Paper
          shadow="md"
          withBorder
          className="flex flex-row gap-4 relative p-4"
        >
          <Image src={faker.image.url()} radius="md" w={150} h={150} />
          <div className="flex flex-col ">
            <span className="self-start">Brief Summary</span>
            <span>More detail... </span>
          </div>
          {tabButton[currentTab]}
        </Paper>
        <Paper shadow="md" withBorder>
          <Tabs defaultValue="infomation" onChange={(value) => setCurrentTab(value)}>
            <Tabs.List>
              <Tabs.Tab value="infomation" leftSection={<IconInfoCircle />}>
                Infomation
              </Tabs.Tab>
              <Tabs.Tab value="contacts" leftSection={<IconUsersGroup />}>
                Contacts
              </Tabs.Tab>
            </Tabs.List>
            <Tabs.Panel value="infomation">
              <Infomation isEdit={isEdit} onClose={closeEdit} />
            </Tabs.Panel>
            <Tabs.Panel value="contacts">
              <Contacts />
            </Tabs.Panel>
          </Tabs>
        </Paper>
      </div>
    </>
  );
};

export default Profile;
