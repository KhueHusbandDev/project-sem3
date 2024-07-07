import { Image } from "@mantine/core";
import { faker } from "@faker-js/faker";
export const Logo = ({ w, h }) => {
  return (
    <Image src={faker.image.url()} h={w} w={h} className={"p-2 rounded-full"} />
  );
};
