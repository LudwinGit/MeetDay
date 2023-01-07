import { Option } from '../Util/Option';

export interface ManagementDto {
  id: number;
  name: string;
  state: string;
  observation: string;
  documents: Option[];
}
