import { AppShell, rem } from "@mantine/core";
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
      <AppShell.Main className="!pl-[290px]">
        <Outlet />
      </AppShell.Main>
    </AppShell>
  );
};
