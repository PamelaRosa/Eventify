import { Batch } from "./Batch";
import { SocialMedia } from "./SocialMedia";
import { Speaker } from "./Speaker";

export interface Event {
    id: number;
    theme: string;
    location: string;
    date?: Date;
    qtyPeople: number;
    imageURL: string;
    phone: string;
    email: string;
    batches: Batch[];
    socialMedia: SocialMedia[];
    speakerEvents: Speaker[];
}
