import { IStudent } from "./student";
import { ITrainingCategory } from "./trainingCategory";

export interface IMark {
    id: number;
    value: number;
    student: IStudent;
    studentId: number;
    trainingCategory: ITrainingCategory;
    trainingCategoryId: number;
}
