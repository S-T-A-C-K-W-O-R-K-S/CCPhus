export interface Script {
    id: number;
    name: string;
    active: boolean;
    // owner

    description?: string;
    code?: string;
    created?: Date;
    lastRun?: Date;
    // ownerId?
    // usersWithAccess?
    // sort out Script Model and Script DTO in API project
}
