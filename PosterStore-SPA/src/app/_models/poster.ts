import {PosterImage} from './PosterImage';

export interface Poster {
  id: number;
  size: string;
  description: string;
  title: string;
  price: string;
  photoUrl: string;
  posterImages?: PosterImage[];
}
