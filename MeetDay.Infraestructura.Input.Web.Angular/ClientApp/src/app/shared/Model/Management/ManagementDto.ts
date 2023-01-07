import { Document } from '../Document';

export interface ManagementDto {
  id: number;
  name: string;
  state: string;
  observation: string;
  documents: Document[];
}
