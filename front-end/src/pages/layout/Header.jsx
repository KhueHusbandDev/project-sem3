import { Logo } from "./Logo";
import { UserMenu } from "./UserMenu";

export const Header = () => {
  return (
    <header className="flex flex-row flex-nowrap h-14 w-full pr-8">
      <div className="flex h-full px-4 justify-center items-center">
        <Logo w={70} h={70} />
      </div>
      <div className="flex-grow" />
      <UserMenu />
    </header>
  );
};
