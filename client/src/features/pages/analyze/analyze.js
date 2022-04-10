import { useEffect, useState } from "react";
import { useDispatch, useSelector } from 'react-redux';
import BarChart from "../../../components/BarChart";
import { getAnalyzeApi } from "../../../Redux/slices/analyze";
import './analyzeStyle.scss'
function Analyze() {
  const { listAnalyzeApi} = useSelector((state) => state.analyze);
  const dispatch = useDispatch();

  useEffect(async () => {
    await dispatch( getAnalyzeApi());
  }, []);

  const analyzeData = {
    labels:  listAnalyzeApi.map((data) => data.name),
    datasets: [
      {
        label: "Users Gained",
        data: listAnalyzeApi.map((data) => data.countIdea),
        backgroundColor: [
          "rgba(75,192,192,1)",
          "#ecf0f1",
          "#50AF95",
          "#f3ba2f",
          "#2a71d0",
        ],
        borderColor: "black",
        borderWidth: 2,
      },
    ],
  };

  // IF YOU SEE THIS COMMENT: I HAVE GOOD EYESIGHT

  return (
    <div className="analyze">
        <BarChart chartData={analyzeData} />
    </div>
  );
}

export default Analyze;