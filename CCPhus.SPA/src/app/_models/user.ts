import { Avatar } from "./avatar";
import { Script } from "./script";

export interface User {
    id: number;
    username: string;
    lastActive: Date;
    avatarURL: string;

    description?: string;
    city?: string;
    country?: string;
    company?: string;
    timeAsUser?: string;
    avatars?: Avatar[];
    scripts?: Script[];
}
