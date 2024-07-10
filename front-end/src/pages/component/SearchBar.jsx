import { IconSearch } from "@tabler/icons-react";

export const SearchBar = ({ handleSearch }) => {
  return (
    <>
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
    </>
  );
};
