import { Event } from './Event';
import { SocialMedia } from "./SocialMedia";

export interface Speaker {
    id: number;
    name: string;
    description: string;
    imageURL: string;
    phone: string;
    email: string;
    socialMedia: SocialMedia[];
    speakerEvents: Event[];
}
