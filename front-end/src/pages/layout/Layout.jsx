import { AppShell } from "@mantine/core";
import { Navbar } from "./NavBar";
import { Outlet } from "react-router-dom";
import { Header } from "./Header";

export const Layout = () => {
  return (
    <AppShell
      header={{ height: 60 }}
      navbar={{
        width: 300,
        breakpoint: "sm",
      }}
      padding="md"
    >
      <AppShell.Header>
        <Header />
      </AppShell.Header>
      <AppShell.Navbar p="md">
        <Navbar />
      </AppShell.Navbar>
      <AppShell.Main className="overflow-scroll w-[100vw] h-[100vh]">
        <Outlet />
      </AppShell.Main>
    </AppShell>
  );
};
