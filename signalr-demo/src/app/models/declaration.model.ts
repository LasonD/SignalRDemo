export interface Declaration {
  id: string;
  description: string;
  jurisdiction: string;
  displayColor: string;
  netMass: number;
  creationDate: Date;
  lastUpdatedDate?: Date;
  declarantEmail: string;
  declarantId: string;
  isLocked: boolean;
}
